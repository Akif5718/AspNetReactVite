import { BrowserRouter, Route, Routes } from "react-router-dom";
import './app.scss'
import Home from "./pages/home/Home";
import Login from "./pages/login/Login";
import Header from "./components/header/Header";
import Footer from "./components/footer/Footer";
import Landing from "./pages/landing/Landing";

function App() {

  return (
    <>
      {
        location.pathname !==  '/login' && location.pathname !==  '/' && <Header />
      }
      <BrowserRouter>
      <Routes>
        <Route path="/" element={<Landing />}/>
        <Route path="/dashboard" element={<Home />}/>
        <Route path="/login" element={<Login />}/>
      </Routes>
     </BrowserRouter>
     {
      location.pathname !== '/login' && location.pathname !==  '/' && <Footer />
     }
    </>
  )
}

export default App;
