import React, { useState, useCallback, useEffect } from "react";

import "./App.css";
import Expenses from "./Components/Expenses";

const App = () => {
  const [expenses, setExpenses] = useState([]);


  const fetchExpensesHandler = useCallback(async () => {
    try {
      const response = await fetch('https://localhost:44359/api/expense');
      if (!response.ok) {
        throw new Error('Something went wrong!');
      }
  
      const data = await response.json();
  
      const loadedExpenses = [];
  
      for (const key in data) {
        loadedExpenses.push({
          id: key,
          title: data[key].title,
          price: data[key].price,
          time: data[key].time,
          category: data[key].category
        });
      }
  
      setExpenses(loadedExpenses);
    } catch (error) {
      console.log(error.message);
    }
  }, []);
  
  useEffect(() => {
    fetchExpensesHandler();
  }, [fetchExpensesHandler]);

  return (
      <Expenses items={expenses} />
  );
};

export default App;
