import { bindActionCreators } from "redux";
import {
  REQUEST_SIGNIN_PENDING,
  REQUEST_SIGNIN_SUCCESS,
  REQUEST_SIGNIN_FAILED,
  REQUEST_FILMLIST_PENDING,
  REQUEST_FILMLIST_SUCCESS,
  REQUEST_FILMLIST_FAILED,
  SET_USER,
} from "./constants.js";

const intialState = {
  user :'',
}

export const setUser = (state = intialState, action ={}) => {
  switch(action.type){
    case SET_USER:
      return {...state, user: action.payload};
    default:
      return state;
  }
}
// const intialStateSignIn = {
//   userEmail: "",
//   password: "",
//   isPending: false,
//   error: "",
// };

// export const signIn = (state = intialStateSignIn, action = {}) => {
//   switch (action.type) {
//     case REQUEST_SIGNIN_PENDING:
//         return { ...state, isPending: true};
//     case REQUEST_SIGNIN_SUCCESS:
//         return { ...state, userEmail: action.payload.userEmail, password: action.payload.password, isPending: false};
//     case REQUEST_SIGNIN_FAILED:
//         return { ...state, error: action.payload, isPending: false};
//     default:
//       return state;
//   }
// };

// export const signIn = (state = intialStateSignIn, action = {}) => {
//     switch (action.type) {
//       case REQUEST_SIGNIN_PENDING:
//           return { ...state, isPending: true};
//       case REQUEST_SIGNIN_SUCCESS:
//           return { ...state, userEmail: action.payload.userEmail, password: action.payload.password, isPending: false};
//       case REQUEST_SIGNIN_FAILED:
//           return { ...state, error: action.payload, isPending: false};
//       default:
//         return state;
//     }
//   };