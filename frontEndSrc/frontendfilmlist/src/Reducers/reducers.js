import {
  SET_USER,
} from "./constants.js";

const intialState = {
  userEmail :'',
  token: '',
}

export const setUser = (state = intialState, action ={}) => {
  switch(action.type){
    case SET_USER:
      return {...state, user: action.payload.userEmail, token: action.payload2.token};
    default:
      return state;
  }
}