import React, { useState } from "react";
import { Button, Col, Container, Form, Row, Table } from "react-bootstrap";
import {
  reverseRequisicion,
  getDocument,
} from "../../Services/DocumentoService";
import useToast from "../../Hooks/useToast";

const RevertDocument = () => {
  //Hooks
  const [doToast, Toaster] = useToast();

  //Automatic fill
  const [Productos, setProductos] = useState([]);

  //UserFil;
  const [Documento, setDocumento] = useState("");

  const handleBuscar = async () => {
    let result = await getDocument(Documento);
    setProductos(result);
  };

  const reverseDocument = async () => {
    let response = await reverseRequisicion(Productos);

    if (response.status === 200) {
      doToast(`Reversion exitosaDocumento`, "success");
      setProductos([]);
    } else {
      doToast("Error al Revertir", "Error");
    }
  };

  return (
    <Container className="mt-5">
      <Row>
        <Col>
          <Form>
            <Form.Row className="align-items-center">
              <Col>
                <Form.Label>#Documento</Form.Label>

                <Form.Control
                  type="text"
                  placeholder="00000"
                  onChange={(e) => setDocumento(e.target.value)}
                ></Form.Control>
              </Col>
              <Col>
                <Form.Label>&nbsp;</Form.Label>
                <Button className="mt-4" onClick={handleBuscar}>
                  Buscar
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
              <th>Costo</th>
            </tr>
          </thead>
          <tbody>
            {Productos.map((item) => (
              <tr key={item.id}>
                <td>{item.productoId}</td>
                <td>{item.producto.nombre}</td>
                <td>{item.loteId}</td>
                <td>{item.cantidad}</td>
                <td>{item.costo}</td>
              </tr>
            ))}
          </tbody>
        </Table>
      </Row>
      <Row className="row justify-content-end">
        <Button variant="warning" onClick={reverseDocument}>
          Revertir Documento
        </Button>
      </Row>
      <Toaster />
    </Container>
  );
};

export default RevertDocument;
