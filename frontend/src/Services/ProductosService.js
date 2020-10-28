import { Config } from "../Config/Config";

const getProductos = async () => {
  var url = `${Config.api_host}producto/getProductos`;

  var request = await fetch(url);
  var response = request.json();
  return response;
};

const getLotes = async (p_id_producto) => {
  var url = `${Config.api_host}lotes/getLotes/${p_id_producto}`;

  var request = await fetch(url);
  var response = request.json();
  return response;
};

const getProductosmovimientos = async (p_fecha) => {
  var url = `${Config.api_host}producto/getMovimientos/${p_fecha}`;

  var request = await fetch(url);
  var response = request.json();
  return response;
};

export { getProductos, getLotes, getProductosmovimientos };
