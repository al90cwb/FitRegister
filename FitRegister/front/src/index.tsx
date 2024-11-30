import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';

// Define o valor inicial de isAuthenticated
if (!localStorage.getItem("isAuthenticated")) {
    localStorage.setItem("isAuthenticated", "false");
}
ReactDOM.render(
  <React.StrictMode>
    <App />
  </React.StrictMode>,
  document.getElementById('root')
);
