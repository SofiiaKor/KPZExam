import React from "react";

const ExpensesFilter = (props) => {
  const dropdownChangeHandler = (event) => {
    props.onChangeFilter(event.target.value);
  };

  return (
    <div>
      <label>Filter by category</label>
      <select value={props.selected} onChange={dropdownChangeHandler}>
        <option value="Entertainment">Entertainment</option>
        <option value="Clothing">Clothing</option>
        <option value="Food">Food</option>
        <option value="Bills">Bills</option>
      </select>
      
      {
        // Doesn't work
      /* <label>Filter by months</label>
      <select>
        <option value="Jan">Jan</option>
        <option value="Fab">Fab</option>
        <option value="Mar">Mar</option>
        <option value="Apr">Apr</option>
        <option value="May">May</option>
        <option value="Jun">Jun</option>
        <option value="Jul">Jul</option>
        <option value="Aug">Aug</option>
      </select> */}
    </div>
  );
};

export default ExpensesFilter;
