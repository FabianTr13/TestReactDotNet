import React, { useState } from "react";
import {
  Container,
  Row,
  Button,
  FormControl,
  InputGroup,
  Col,
} from "react-bootstrap";
import { getProductosmovimientos } from "../../Services/ProductosService";
import useToast from "../../Hooks/useToast";
import TableData from "./Components/TableResult";

const MovimientosView = () => {
  //Hooks
  const [doToast, Toaster] = useToast();

  //State Variables
  const [fecha, setfecha] = useState("");
  const [movimientos, setmovimientos] = useState([]);

  //Functions
  const GeResult = async () => {
    if (fecha === "") {
      doToast("Seleccione una fecha", "Error");
      return;
    }
    var result = await getProductosmovimientos(fecha);
    setmovimientos(result);
  };

  //Layout
  return (
    <Container className="mt-5">
      <Row>
        <Col xs={12} sm={4} md={4} lg={3}>
          <InputGroup className="mb-3">
            <FormControl
              placeholder="2020-10-01"
              data-date-format="yyyy-MM-dd"
              type="date"
              onChange={(e) => setfecha(e.target.value)}
            />
            <InputGroup.Append>
              <Button variant="outline-secondary" onClick={GeResult}>
                Ver
              </Button>
            </InputGroup.Append>
          </InputGroup>
        </Col>
      </Row>
      <Row>
        <TableData tableData={movimientos} />
      </Row>
      <Toaster />
    </Container>
  );
};

export default MovimientosView;
