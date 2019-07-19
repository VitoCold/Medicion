import React from "react";
import { NavLink } from "react-router-dom";
import LogoCtgs from "../assets/logoctg.png";
import { FaIndustry, FaServer, FaPlus, FaSignOutAlt} from "react-icons/fa";
const Header = () => {
  const activeStyle={color:"#6666ff"};
  return (
    <nav className="navbar navbar-expand-sm bg-light navbar-light justify-content-end">
      <NavLink className="navbar-brand" to="/">
        <img src={LogoCtgs} alt="logoContugas"/>
      </NavLink>
      <NavLink className="navbar-brand" to="/">
       <div className="small font-weight-bold text-success"> Base de Datos de Medición</div>
      </NavLink>
      <ul className="navbar-nav ml-auto mr-1">
      <li className="nav-item active">
      </li>
      <li className="nav-item active">
      <NavLink to="/industrias" className="nav-link" activeStyle={activeStyle}>
        <FaIndustry /> Industrias
      </NavLink>
      </li>
      <li className="nav-item active">
      <NavLink to="/datasheets" className="nav-link" activeStyle={activeStyle}>
      <FaServer /> Hojas técnicas
      </NavLink>
      </li>
      <li className="nav-item active">
        <div className="dropdown">
          <span className="badge badge-success dropdown-toggle">
            VD
          </span>
          <div className="dropdown-content">
            <NavLink className="dropdown-item" to="#">
              <FaPlus/> industria
            </NavLink>
            <NavLink className="dropdown-item" to="#">
              <FaPlus/> hoja técnica
            </NavLink>
            <NavLink className="dropdown-item" to="#">
              <FaSignOutAlt/> salir
            </NavLink>
          </div>
        </div>
      </li>
      </ul>
    </nav>
   
  );
};

export default Header;