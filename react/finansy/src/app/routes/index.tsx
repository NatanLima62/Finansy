import {Route, Routes} from "react-router-dom";

export const AppRoutes = () => {
  return (
    <Routes>
      <Route path="*" element={<h1>Página inicial</h1>} />
    </Routes>
  );
};