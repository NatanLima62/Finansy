import { Box, Button, TextField, Typography } from "@mui/material";
import React from "react";
import "./index.css";

export const LoginAdmin = () => {
  return (
    <Box width="100vw" height="100vh" display="flex">
      <Box
        minWidth="50%"
        display="flex"
        alignItems="center"
        justifyContent="center"
      >
        <Box
          width="50%"
          height="50%"
          display="flex"
          flexDirection="column"
          alignItems="center"
          justifyContent="space-between"
          sx={{ background: "lightgray" }}
        >
          <Box padding="6rem 0 0 0">
            <Typography variant="h2">Finansy Admin</Typography>
          </Box>
          <Box
            display="flex"
            flexDirection="column"
            gap="2rem"
            width="90%"
            padding="0 0 10rem 0"
          >
            <TextField variant="outlined" label="Email" required />
            <TextField variant="outlined" label="Senha" required />
            <div className="login-adm-links">
                <a>Logar como gerente</a>
                <a>Esqueceu a senha?</a>
            </div>
            <Button variant="contained">Login</Button>
          </Box>
        </Box>
      </Box>
      <Box width="50%" sx={{ background: "black" }}>
        Box responsavel por conter a imagem
      </Box>
    </Box>
  );
};
