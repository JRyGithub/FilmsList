import React, { useState, useEffect } from "react";
import styled from "styled-components";
import NavBar from "../Components/navBar";
import { Link } from "react-router-dom";
import { useParams } from "react-router-dom";
import axios from "axios";

export const FilmList = (props) => {
  const [filmName, setFilmName] = useState("");
  const [directorName, setDirectorName] = useState("");
  const [genre, setGenre] = useState("");
  const [filmList, setFilmList] = useState([]);
  let { userEmail, token } = useParams();

  useEffect(() => {
    var config = {
      method: "post",
      url: `https://localhost:5001/api/UsersFilms?userEmail=${userEmail}`,
      headers: {
        "Content-Type": "application/json",
        Authorization: `Bearer ${token}`,
      },
    };

    axios(config)
      .then(function (response) {
        console.log("Axios");
        console.log(response.data);
        console.log(typeof response.data)
        const arrayOfFilms = Object.keys(response.data)
        console.log(typeof arrayOfFilms);

        response.data.forEach(film => {
          setFilmList(prevItems => [...prevItems, film]);
        });        
      })
      .catch(function (error) {
        console.log(error);
      });
  }, [userEmail, token]);

  return (
    <>
      <Link path="/">
        <NavBar />
      </Link>
      <Container>
        <Table>
          <Tr>
            <Th>Film Name</Th>
            <Th>Director</Th>
            <Th>Genre</Th>
          </Tr>
          {filmList.map(film => (
            <Tr>
            <Td>{film.filmName}</Td>
            <Td>{film.directorName}</Td>
            <Td>{film.genre}</Td>
          </Tr>
          ))}
          <Tr>
            <Td>
              <Input
                type="text"
                value={filmName}
                onChange={(event) => setFilmName(event.target.value)}
              ></Input>
            </Td>
            <Td>
              <Input
                type="text"
                value={directorName}
                onChange={(event) => setDirectorName(event.target.value)}
              ></Input>
            </Td>
            <Td>
              <Input
                type="text"
                value={genre}
                onChange={(event) => setGenre(event.target.value)}
              ></Input>
              <Button>Add</Button>
            </Td>
          </Tr>
        </Table>
      </Container>
    </>
  );
};

export default FilmList;

const Container = styled.div``;
const Table = styled.table`
  font-family: arial, sans-serif;
  border-collapse: collapse;
  width: 100%;
`;
const Tr = styled.tr`
  &:nth-child(even) {
    background-color: #dddddd;
  }
`;
const Th = styled.th`
  border: 1px solid #dddddd;
  text-align: left;
  color: white;
  padding: 8px;
  background-color: #36454f;
`;
const Td = styled.td`
  border: 1px solid #dddddd;
  text-align: left;
  padding: 8px;
`;
const Input = styled.input`
  width: 80%;
  box-sizing: border-box;
`;
const Button = styled.button`
  background-color: #4caf50;
  border: none;
  color: white;
  text-decoration: none;
  margin: 4px 2px;
  cursor: pointer;
  width: 15%;
  margin-left: 10px;
`;
