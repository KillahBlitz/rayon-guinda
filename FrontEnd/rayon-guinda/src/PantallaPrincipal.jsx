import {Box, Center, FormControl, FormLabel, Heading, Input, Image } from '@chakra-ui/react';
import { useNavigate } from "react-router";
import redbuddy from "./media/buddyred.png";


export function PantallaPrincipal(){
    return(
        <>
        <Box bg="#4A0000" minHeight="100vh" width="100vw" overflow="hidden" m={0} p={0} fontFamily={"Open Sans"}>
            <Box bg="#ffffff"  mt="5%" ml="15%" mr="1%" mb="1%" fontFamily={"Open Sans"}>
                <h1>Helloworld</h1>
            </Box>
        </Box>
        </>
    )
}