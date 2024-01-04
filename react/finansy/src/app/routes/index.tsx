import { Route, Routes } from "react-router-dom";
import { LoginAdmin } from "../pages";

export const AppRoutes = () => {
  return (
    <Routes>
      <Route path="*" element={<h1>Página inicial</h1>} />
      <Route path="/login-adm" element={<LoginAdmin />} />
    </Routes>
  );
};
