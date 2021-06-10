import {
  SET_USER,
} from "./constants.js";

export const setUser = (user, token) => ({
  type: SET_USER,
  payload: user,
  payload2: token,
});