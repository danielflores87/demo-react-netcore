import { lazy, Suspense } from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import { AppContextProvider } from "./app.context";
import "./App.css";
import { HeaderComponent } from "./componets/header.component";
import HomePage from "./pages/home.page";
import LoginPage from "./pages/login.page";

function App() {
  const CreateUserPage = lazy(() => import("./pages/users/create-user.page"));
  const SearchUserPage = lazy(() => import("./pages/users/search-user.page"));
  return (
    <AppContextProvider>
      <Router>
        <>
          <HeaderComponent />
          <Suspense fallback={<div>Loading...</div>}>
            <Routes>
              <Route path="/login" element={<LoginPage />} />
              <Route path="/users/create" element={<CreateUserPage />} />
              <Route path="/users" element={<SearchUserPage />} />
              <Route path="/*" element={<HomePage />} />
            </Routes>
          </Suspense>
        </>
      </Router>
    </AppContextProvider>
  );
}

export default App;
