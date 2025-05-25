import {Routes,Route} from "react-router"
import { PantallaLogin } from './PantallaLogin';
import { PantallaRegistro } from "./PantallaRegistro";
import { PantallaRecuperarC } from "./PantallaRecuperarC";
import { PantallaCambiarC} from "./PantallaCambiarC";
import { PantallaPrincipal } from "./PantallaPrincipal";
import { PantallaEditarPerfil } from "./PantallaEditarPerfil";
import { PantallaModificadoraDatos } from "./PantallaModificadoraDatos";
import { SubPantallaGrupos } from "./SubPantallaGrupos";



export function App() {

  return (
      <Routes>
        <Route path="/" element={<PantallaLogin />} />
        <Route path="/PantallaRegistro" element={<PantallaRegistro />} />
        <Route path="/PantallaRecuperarC" element={<PantallaRecuperarC />} />
        <Route path="/PantallaCambiarC" element={<PantallaCambiarC />} />
        
        <Route path="/PantallaPrincipal" element={<PantallaPrincipal />} />
        <Route path="/SubPantallaGrupos" element={<SubPantallaGrupos />} />
        <Route path="/PantallaEditarPerfil" element={<PantallaEditarPerfil />} />
        <Route path="/PantallaModificadoraDatos" element={<PantallaModificadoraDatos />} />
      </Routes>
  )
}

export default App;