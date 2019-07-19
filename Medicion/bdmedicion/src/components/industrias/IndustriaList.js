import React from "react";
import PropTypes from "prop-types";
import { Link } from "react-router-dom";

const IndustriaList = ({ industrias }) => (
  <div className="table-responsive-sm">
    <hr/>
  <table className="table table-striped table-sm table-hover">
    <thead>
      <tr>
        <th>#</th>
        <th>Tag</th>
        <th>Nombre</th>
        <th>Elemento</th>
      </tr>
    </thead>
    <tbody>
      {industrias.map(industria => {
        return (
          <tr key={industria.industriaId}>
            <td>
              {industria.industriaId}
            </td>
            <td>
              {industria.tag}
            </td>
            <td>
              <Link to={"/industrias/" + industria.nombre}>{industria.nombre}</Link>
            </td>
            <td className="botones">
                <button className="btn btn-primary btn-sm">P</button> &nbsp;
                <button className="btn btn-secondary btn-sm">S</button> &nbsp;
                <button className="btn btn-success btn-sm">T</button>
            </td>
          </tr>
        );
      })}
    </tbody>
  </table>
  </div>
);

IndustriaList.propTypes = {
  industrias: PropTypes.array.isRequired
};

export default IndustriaList;
