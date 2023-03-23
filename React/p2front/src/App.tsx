import { useState } from 'react';
import './App.css';
import { IPatient } from './models/patient';
import { BrowserRouter } from 'react-router-dom';
import { Route, Routes } from 'react-router';
import LoginP from './components/login-p/LoginP';
import LoginE from './components/login-e/LoginE';
import Home from './components/home/Home';
import { IEmployee } from './models/employee';
import RegisterP from './components/register-p/RegisterP';
import RegisterE from './components/register-e/RegisterE';
import DashboardP from './components/dashboard-p/DashboardP';
import DashboardE from './components/dashboard-e/DashboardE';
import MakeClaim from './components/make-claim/MakeClaim';
import ViewAllClaims from './components/view-all-claims/ViewAllClaims';
import ViewClaimsPatient from './components/view-claims-patient/ViewClaimsPatient';
import ViewPending from './components/view-pending/ViewPending';
import PasswordE from './components/password-e/PasswordE';
import PasswordP from './components/password-p/PasswordP';

function App() {

  const [authPatient, setAuthPatient] = useState<IPatient>();
  const [authEmployee, setAuthEmployee] = useState<IEmployee>();

  return (
    <div id="box">
      <h1>Healthcare Insurance Claims Application</h1>
      <BrowserRouter>
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/loginP" element={<LoginP currentUser={authPatient} setCurrentUser={setAuthPatient} />} />
          <Route path="/loginE" element={<LoginE currentUser={authEmployee} setCurrentUser={setAuthEmployee} />} />

          <Route path="/registerP" element={<RegisterP currentUser={authPatient} setCurrentUser={setAuthPatient} />} />
          <Route path="/registerE" element={<RegisterE currentUser={authEmployee} setCurrentUser={setAuthEmployee} />} />

          <Route path="/dashboardP" element={<DashboardP currentUser={authPatient} setCurrentUser={setAuthPatient} />} />
          <Route path="/dashboardE" element={<DashboardE currentUser={authEmployee} setCurrentUser={setAuthEmployee} />} />

          <Route path="/makeClaim" element={<MakeClaim currentUser={authPatient} setCurrentUser={setAuthPatient}/>} />
          <Route path="/viewAllClaims" element={<ViewAllClaims currentUser={authEmployee} setCurrentUser={setAuthEmployee}/>} />
          <Route path="/viewClaimsPatient" element={<ViewClaimsPatient currentUser={authPatient} setCurrentUser={setAuthPatient} />} />
          <Route path="/viewPending" element={<ViewPending currentUser={authEmployee} setCurrentUser={setAuthEmployee}/>} />

          <Route path="/changePassP" element={<PasswordP currentUser={authPatient} setCurrentUser={setAuthPatient} />} />
          <Route path="/changePassE" element={<PasswordE currentUser={authEmployee} setCurrentUser={setAuthEmployee} />} />
        </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;
