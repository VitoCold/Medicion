import React from "react";
import { Link } from "react-router-dom";

const DataSheetsPage = () => (
  <div className="jumbotron">
    <h1>Datasheets</h1>
    <Link to="/" className="btn btn-primary btn-lg">
      Home
    </Link>
    &nbsp;
    <Link to="/industrias" className="btn btn-success btn-lg">
      Industrias
    </Link>
  </div>
);

export default DataSheetsPage;