import React, { useState } from "react";
import {
  CButton,
  CModal,
  CModalBody,
  CModalFooter,
  CModalHeader,
  CModalTitle,
} from "@coreui/react";

const UseModalConfirm = () => {
  const [show, setShow] = useState(false);

  const handleExit = () => {
    setShow(false);
  };

  const presentModal = () => {
    setShow(true);
  };

  const ModalConfirm = () => (
    <CModal show={show} onClose={handleExit}>
      <CModalHeader closeButton>
        <CModalTitle>Advertencia de reversion</CModalTitle>
      </CModalHeader>
      <CModalBody>Esta accion retornara los productos al inventario</CModalBody>
      <CModalFooter>
        <CButton
          color="primary"
          onClick={async () => {
            setShow(false);
          }}
        >
          Aplicar
        </CButton>{" "}
        <CButton color="secondary" onClick={handleExit}>
          Cancelar
        </CButton>
      </CModalFooter>
    </CModal>
  );

  return [presentModal, ModalConfirm];
};

export default UseModalConfirm;
