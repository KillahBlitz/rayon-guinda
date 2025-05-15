import {Routes,Route} from "react-router"
import { PantallaLogin } from './PantallaLogin';
import { PantallaRecuperarC } from "./PantallaRecuperarC";
import { PantallaRegistro } from "./PantallaRegistro";

export function App() {

  return (
      <Routes>
        <Route path="/" element={<PantallaLogin />} />
        <Route path="/PantallaRecuperarC" element={<PantallaRecuperarC />} />
        <Route path="/PantallaRegistro" element={<PantallaRegistro />} />
      </Routes>
  )
}

export default App;