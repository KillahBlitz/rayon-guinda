import {Routes,Route} from "react-router"
import { PantallaLogin } from './PantallaLogin';
import { PantallaRegistro } from "./PantallaRegistro";
import { PantallaRecuperarC } from "./PantallaRecuperarC";
import { PantallaCambiarC} from "./PantallaCambiarC";
import { PantallaPrincipal } from "./PantallaPrincipal";


export function App() {

  return (
      <Routes>
        <Route path="/" element={<PantallaLogin />} />
        <Route path="/PantallaRegistro" element={<PantallaRegistro />} />
        <Route path="/PantallaRecuperarC" element={<PantallaRecuperarC />} />
        <Route path="/PantallaCambiarC" element={<PantallaCambiarC />} />
        
        <Route path="/PantallaPrincipal" element={<PantallaPrincipal />} />
      </Routes>
  )
}

export default App;