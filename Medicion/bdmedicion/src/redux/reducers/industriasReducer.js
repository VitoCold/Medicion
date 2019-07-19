import * as types from "../actions/actionTypes";
import initialState from "./initialState";

export default function industriaReducer(state = initialState.industrias, action) {
  switch (action.type) {
    case types.LOAD_INDUSTRIAS_SUCCESS:
      return action.industrias;
    default:
      return state;
  }
}
