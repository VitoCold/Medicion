import { handleResponse, handleError } from "./apiUtils";
const baseUrl = process.env.API_URL + "/industria/";

// const email = "administrador@contugas.com.pe";
// const password = "Ctg2019.Admin";
// const grantType="grant-type";

export function getIndustrias() {
  return fetch(baseUrl+"list", {
    method: "GET",
    headers: {
      Authorization: "Bearer 6-nDOGLNZkANbYq5M4SNDGS4I6Mlk37prDOi_oKvjSFJBTJ8aVbL8FRTMdXZ3QpNNz5m7K2iJ7KcbhDeB92IvCHs72Y46i3Fj8uMsnlLBlAjNQ_5ThioaUYgaZoqr91cEjKGSGoTtSBCkfRNPNu8WqjWUP6EHEies_CEnOqSVK2r9iPMjaFHNLWm4pKLOZkk7HtDiu2C15VgfWHKr8001A9I0u5qQ2Z3tj34oGBwDgxYYDSZXcSatW5oPuHOlSNPrhPZ6SIF2hja_iDHM3ahgw"
    }
  })
    .then(handleResponse)
    .catch(handleError);
}
