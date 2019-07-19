import React from "react";
import { Link } from "react-router-dom";

const HomePage = () => (
  <div className="jumbotron">
    <h1>Subgerencia de Operaciones</h1>
    <p>Base de datos de los sistemas de medición de Contugas e Industrias</p>
    <Link to="/industrias" className="btn btn-primary btn-lg">
      Industrias
    </Link>
    &nbsp;
    <Link to="/datasheets" className="btn btn-success btn-lg">
      Hojas de datos
    </Link>
  </div>
);

export default HomePage;