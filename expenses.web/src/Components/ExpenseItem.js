function ExpenseItem(props) {
  let category = "Entertainment";

  switch (props.category) {
    case 0:
      category = "Entertainment";
      break;
    case 1:
      category = "Clothing";
      break;
    case 2:
      category = "Food";
      break;
    case 3:
      category = "Bills";
      break;
  }

  return (
    <li>
      <h2>{props.title}</h2>
      <div>Amount spent: ${props.price}</div>
      <div>Day and time when spent: {props.time}</div>
      <div>Category: {category}</div>
    </li>
  );
}

export default ExpenseItem;
