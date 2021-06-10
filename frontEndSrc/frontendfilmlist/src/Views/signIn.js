import React, { useState } from "react";
import styled from "styled-components";
import { Link, useHistory } from "react-router-dom";
import axios from "axios";
import { setUser } from "../Reducers/actions";
import { connect } from "react-redux";

const mapStateToProps = (state) => {
  return {
    userEmail: state.setUser.userEmail,
  };
};

const mapDispatchToProps = (dispatch) => {
  return {
    onUserLogin: (user, token) => dispatch(setUser(user, token)),
  };
};

export const SignIn = (props) => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [signInSuccess, setSignInSuccess] = useState(true);

  const { onUserLogin } = props;

  const history = useHistory();
  const login = () => {
    var data = JSON.stringify({"userEmail": email,"password": password});
    
    var config = {
      method: 'post',
      url: 'https://localhost:5001/api/Login',
      headers: { 
        'Content-Type': 'application/json'
      },
      data : data
    };
    
    axios(config)
    .then(function (response) {
        console.log(response.data.token);
        if(response.status === 200){
          onUserLogin(email, response.data.token);
          history.push(`/filmList/${email}/${response.data.token}`);
        }
    })
    .catch(function (error) {
      setSignInSuccess(false);
      console.log("Sign in failed.");
      console.log(error);
    });
    
  };
  const createAccount = () => {
  };
  return (
    <Container>
      <h1>Log In</h1>
      <Input
        type="email"
        value={email}
        onChange={(event) => setEmail(event.target.value)}
      />
      <Input
        type="password"
        value={password}
        onChange={(event) => setPassword(event.target.value)}
      />
      <Button type="submit" onClick={login}>
        Submit
      </Button>
      <StyledLink to="/resetPassword">
        <Button>Reset Password</Button>
      </StyledLink>
      <StyledLink to="/createAccount">
        <Button>Create Account</Button>
      </StyledLink>
    </Container>
  );
};

export default connect(mapStateToProps, mapDispatchToProps)(SignIn);

const Container = styled.div`
  display: flex;
  flex-direction: column;
  justify-content: center;
  gap: 10px;
  width: 100%;
  min-height: 100vh;
  align-items: center;
  text-align: center;
`;
const StyledLink = styled(Link)`
  display: flex;
  flex-direction: column;
  justify-content: center;
`;
const Input = styled.input``;
const Button = styled.button`
  font-size: 12px;
`;
