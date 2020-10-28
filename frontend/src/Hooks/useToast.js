import React from "react";
import { ToastContainer, toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

const useToast = () => {
  const doToast = (message, state) => {
    setTimeout(() => {
      state === "success" ? ToastSuccess(message) : ToastError(message);
    }, 300);
  };

  const ToastSuccess = (message) => {
    toast.success(`🚀 ${message}`, {
      position: "top-right",
      autoClose: 10000,
      hideProgressBar: false,
      closeOnClick: true,
      pauseOnHover: true,
      draggable: true,
      progress: undefined,
    });
  };

  const ToastError = (message) => {
    toast.error(`🥺 ${message}`, {
      position: "top-right",
      autoClose: 3000,
      hideProgressBar: false,
      closeOnClick: true,
      pauseOnHover: true,
      draggable: true,
      progress: undefined,
    });
  };

  const Toaster = () => <ToastContainer />;

  return [doToast, Toaster];
};

export default useToast;
