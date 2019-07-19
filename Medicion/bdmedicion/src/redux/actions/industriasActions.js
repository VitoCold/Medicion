import * as types from "./actionTypes";
import * as industriasApi from "../../api/industriasApi";
import { beginApiCall, apiCallError } from "./apiStatusActions";

export function loadIndustriasSuccess(industrias) {
  return { type: types.LOAD_INDUSTRIAS_SUCCESS, industrias};
}

export function loadIndustrias() {
  return function(dispatch) {
    dispatch(beginApiCall());
    return industriasApi
      .getIndustrias()
      .then(industrias => {
        dispatch(loadIndustriasSuccess(industrias));
      })
      .catch(error => {
        dispatch(apiCallError(error));
        throw error;
      });
  };
}
