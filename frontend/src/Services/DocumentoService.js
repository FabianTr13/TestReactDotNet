import { Config } from "../Config/Config";

const setRequisicion = async (productos) => {
  var url = `${Config.api_host}documento/setRequisicion`;

  var response = await fetch(url, {
    method: "POST",
    body: JSON.stringify(productos),
    headers: {
      "Content-Type": "application/json",
    },
  });

  let result;
  if (response.status === 200) {
    result = await response.json();
  } else {
    result = { idDocumento: undefined };
  }

  console.log("requi", result);

  return result;
};

const getDocument = async (id) => {
  var url = `${Config.api_host}documento/getDocumento/${id}`;

  var response = await fetch(url);
  var result = await response.json();

  return result;
};

const reverseRequisicion = async (productos) => {
  var url = `${Config.api_host}documento/revertDocumento`;

  var response = await fetch(url, {
    method: "POST",
    body: JSON.stringify(productos),
    headers: {
      "Content-Type": "application/json",
    },
  });
  console.log(response);
  return response;
};

export { setRequisicion, reverseRequisicion, getDocument };
