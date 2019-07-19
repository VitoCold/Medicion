import { combineReducers } from "redux";
import apiCallsInProgress from "./apiStatusReducer";
import industrias from "./industriasReducer";

const rootReducer = combineReducers({
  industrias,
  apiCallsInProgress
});

export default rootReducer;
