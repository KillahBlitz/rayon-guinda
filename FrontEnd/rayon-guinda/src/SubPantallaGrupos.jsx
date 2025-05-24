import {Box, Center, Input, Button, HStack} from '@chakra-ui/react';
import * as API from "./services/data";
import { useEffect, useState } from 'react';


export function SubPantallaGrupos() {
    const [grupos, setGrupos] = useState([]);
    const idUsuario = localStorage.getItem('idUsuario');

    
    useEffect(() => {
        API.RecuperarGruposUsuario(idUsuario)
            .then(data => {
                setGrupos(data);
            })}, [idUsuario]);
    
    return (
    <>
        <Center>
            <Box mt='30px'>
                    <Box textAlign='center' fontSize='30px'>
                        <h1>Grupos a los que Perteneces</h1>
                    </Box>
            </Box>
        </Center>
        <HStack spacing='20px' padding='20px' alignItems='center'>
            {// Mapeo de </HStack>los grupos para mostrarlos en la pantalla en forma de botones solo el nombre
            grupos.map((grupo) => (
                <Box key={grupo} padding='10px'>
                    <Button width='200px' height='100px' bgColor='#4A0000' color='white' variant='solid' fontSize='18px'>{grupo}</Button>
                </Box>
            ))}
            <Box padding='10px'>
                <Button width='100px' height='100px' bgColor='#4A0000' color='white' variant='solid' fontSize='40px'>+</Button>
            </Box>
        </HStack>
    </>)
}