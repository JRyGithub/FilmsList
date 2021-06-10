import './App.css';
import { BrowserRouter } from "react-router-dom";
import { MyRouter } from "./Route/router";

function App() {
  return (
    <BrowserRouter basename="/">
      <MyRouter />
    </BrowserRouter>
  );
}

export default App;
