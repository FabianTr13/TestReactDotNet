import React, { useState, useEffect } from "react";
import { Button, Col, Container, Form, Row, Table } from "react-bootstrap";
import { getProductos, getLotes } from "../../Services/ProductosService";
import { setRequisicion } from "../../Services/DocumentoService";
import { BsFillTrashFill } from "react-icons/bs";
import useToast from "../../Hooks/useToast";

const RequisicionView = () => {
  //Hooks
  const [doToast, Toaster] = useToast();

  //Automatic fill
  const [Productos, setProductos] = useState([]);
  const [Lotes, setLotes] = useState([]);

  //UserFil;
  const [Producto, setProducto] = useState({});
  const [ProductoRequire, setProductoRequire] = useState([]);

  useEffect(() => {
    const get = async () => {
      var productos = await getProductos();
      setProductos(productos);
    };
    get();
  }, []);

  const addProducto = () => {
    if (Producto.lote === undefined) {
      doToast("Seleccione un lote", "Error");
      return;
    }

    //Chekeamos no exista en producto
    let existe = ProductoRequire.filter(
      (x) =>
        Number(x.id) === Number(Producto.id) &&
        Number(x.loteId) === Number(Producto.loteId)
    );

    if (existe.length > 0) {
      doToast("El producto ya existe", "Error");
      return;
    }

    if (
      Producto.cantidad === undefined ||
      Number(Producto.cantidad) <= 0 ||
      Number(Producto.cantidad) > Number(Producto.lote.cantidadRestante)
    ) {
      doToast("Cantidad fuera de rango", "Error");
    } else {
      setProductoRequire([...ProductoRequire, Producto]);
    }
  };

  const removeItem = ({ id, loteId }) => {
    let productosNew = ProductoRequire.filter((x) => {
      if (Number(x.id) === Number(id) && Number(x.loteId) === Number(loteId)) {
      } else {
        return x;
      }
    });

    setProductoRequire(productosNew);
  };

  const crearRequisicion = async () => {
    if (ProductoRequire.length === 0) {
      doToast("Ingrese productos", "Error");
      return;
    }

    let productosFill = ProductoRequire.map((item) => {
      let obj = {
        productoId: item.id,
        loteid: item.loteId,
        cantidad: item.cantidad,
      };
      return obj;
    });

    let productosRequest = {
      productos: productosFill,
    };

    let response = await setRequisicion(productosRequest);

    if (response.idDocumento !== undefined) {
      doToast(`Creado con exito Documento: ${response.idDocumento}`, "success");

      var productos = await getProductos();
      setProductos(productos);
      setProducto({});
      setProductoRequire([]);
    } else {
      doToast("Error al crear", "Error");
    }
  };
  return (
    <Container className="mt-5">
      <Row>
        <Col>
          <Form>
            <Form.Row className="align-items-center">
              <Col>
                <Form.Label>Producto</Form.Label>
                <Form.Control
                  as="select"
                  onChange={async (e) => {
                    var proSelec = Productos.filter((obj) => {
                      return Number(obj.id) === Number(e.target.value);
                    })[0];

                    setProducto({
                      ...Producto,
                      id: e.target.value,
                      producto: proSelec,
                    });
                    //get lotes
                    var lotes = await getLotes(e.target.value);
                    setLotes(lotes);
                  }}
                >
                  <option key={0} value={null}>
                    Seleccione
                  </option>
                  {Productos.map((item) => (
                    <option key={item.id} value={item.id}>
                      {item.nombre}
                    </option>
                  ))}
                </Form.Control>
              </Col>
              <Col>
                <Form.Label>Lotes</Form.Label>
                <Form.Control
                  as="select"
                  onChange={async (e) => {
                    let loteSelect = Lotes.filter((obj) => {
                      return Number(obj.loteId) === Number(e.target.value);
                    })[0];

                    setProducto({
                      ...Producto,
                      loteId: e.target.value,
                      lote: loteSelect,
                    });
                  }}
                >
                  <option key={588} value={null}>
                    seleccione
                  </option>
                  {Lotes.map((item) => (
                    <option key={item.loteId} value={item.loteId}>
                      LoteID: {item.loteId} | Cant:{item.cantidadRestante}
                    </option>
                  ))}
                </Form.Control>
              </Col>
              <Col>
                <Form.Label>Cantidad</Form.Label>
                <Form.Control
                  type="number"
                  placeholder="0"
                  onChange={(e) =>
                    setProducto({
                      ...Producto,
                      cantidad: e.target.value,
                    })
                  }
                />
              </Col>
              <Col>
                <Form.Label>&nbsp;</Form.Label>
                <Button className="mt-4" onClick={addProducto}>
                  Agregar
                </Button>
              </Col>
            </Form.Row>
          </Form>
        </Col>
      </Row>
      <Row className="mt-5">
        <Table striped bordered hover>
          <thead>
            <tr>
              <th>idProducto</th>
              <th>Nombre</th>
              <th>Lote</th>
              <th>Cantidad</th>
              <th>
                <BsFillTrashFill />
              </th>
            </tr>
          </thead>
          <tbody>
            {ProductoRequire.map((item) => (
              <tr key={item.id + item.loteId}>
                <td>{item.id}</td>
                <td>{item.producto.nombre}</td>
                <td>{item.loteId}</td>
                <td>{item.cantidad}</td>
                <td>
                  <Button variant="danger" onClick={(e) => removeItem(item)}>
                    <BsFillTrashFill />
                  </Button>
                </td>
              </tr>
            ))}
          </tbody>
        </Table>
      </Row>
      <Row className="row justify-content-end">
        <Button onClick={crearRequisicion}>Crear requisicion</Button>
      </Row>
      <Toaster />
    </Container>
  );
};

export default RequisicionView;
