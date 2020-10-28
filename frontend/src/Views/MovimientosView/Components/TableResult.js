import React from "react";
import { Table } from "react-bootstrap";

const TableResult = ({ tableData }) => {
  return (
    <React.Fragment>
      <Table striped bordered hover>
        <thead>
          <tr>
            <th>ProdutoId</th>
            <th>Nombre</th>
            <th>DocumentoId</th>
            <th>Tipo</th>
            <th>Cantidad</th>
            <th>Lote</th>
            <th>Restante</th>
          </tr>
        </thead>
        <tbody>
          {tableData.map((item) => (
            <tr key={item["id"]}>
              <td>{item["productoId"]}</td>
              <td>{item["producto"]["nombre"]}</td>
              <td>{item["documentoId"]}</td>
              <td>{item["tipoTransaccion"]["descripcion"]}</td>
              <td>{item["cantidad"]}</td>
              <td>{item["loteId"]}</td>
              <td>{item["cantidadRestante"]}</td>
            </tr>
          ))}
        </tbody>
      </Table>
    </React.Fragment>
  );
};

export default TableResult;
