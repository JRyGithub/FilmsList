import {
  REQUEST_SIGNIN_PENDING,
  REQUEST_SIGNIN_SUCCESS,
  REQUEST_SIGNIN_FAILED,
  REQUEST_FILMLIST_PENDING,
  REQUEST_FILMLIST_SUCCESS,
  REQUEST_FILMLIST_FAILED,
  SET_USER,
} from "./constants.js";

export const setUser = (userEmail) => ({
  type: SET_USER,
  payload: userEmail,
});