import React from "react";
import { Route, Switch } from "react-router-dom";
import Header from "./common/Header";
import HomePage from "./home/HomePage";
import IndustriasPage from "./industrias/IndustriasPage";
import DataSheetsPage from "./datasheets/DataSheetsPage";
import PageNotFound from "../PageNotFound";
import { ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

function App() {
  return (
    <div className="container-fluid">
      <Header />
      <Switch>
        <Route exact path="/" component={HomePage} />
        <Route path="/industrias" component={IndustriasPage} />
        <Route path="/datasheets" component={DataSheetsPage} />
        <Route component={PageNotFound} />
      </Switch>
      <ToastContainer autoClose={3000} hideProgressBar />
    </div>
  );
}

export default App;
