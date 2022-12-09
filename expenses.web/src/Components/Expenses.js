import React, { useState } from "react";

import ExpensesFilter from "./ExpensesFilter";
import ExpensesList from "./ExpensesList";

const Expenses = (props) => {
  const [filteredCategory, setFilteredCategory] = useState("");

  const filterChangeHandler = (selectedCategory) => {
    setFilteredCategory(selectedCategory);
  };

  let helper = 0;
  const filteredExpenses = props.items.filter((expense) => {
    switch (filteredCategory) {
      case "Entertainment":
        helper = 0;
        break;
      case "Clothing":
        helper = 1;
        break;
      case "Food":
        helper = 2;
        break;
      case "Bills":
        helper = 3;
        break;
    }

    return expense.category === helper;
  });

  return (
    <React.Fragment>
      <ExpensesFilter
        selected={filteredCategory}
        onChangeFilter={filterChangeHandler}
      />
      <ExpensesList items={filteredExpenses} />
    </React.Fragment>
  );
};

export default Expenses;
