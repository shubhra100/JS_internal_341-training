// Task 1: Student Marks - Average using reduce()
let marks = [80, 90, 70, 85, 95];
let total = marks.reduce((sum, mark) => sum + mark, 0);
let average = total / marks.length;
console.log("Average Marks:", average);



// Task 2: Filter Even Numbers
let numbers = [1,2,3,4,5,6,7,8,9];
let evenNumbers = numbers.filter(num => num % 2 === 0);
console.log("Even Numbers:", evenNumbers);



// Task 3: Shopping Cart - Total Bill
let cart = {
  item: "Laptop",
  price: 45000,
  quantity: 2
};

let totalBill = cart.price * cart.quantity;
console.log("Item:", cart.item);
console.log("Total Bill:", totalBill);



// Task 4: Movie List
let movies = ["Inception", "Interstellar", "Avatar"];
movies.push("The Dark Knight");
movies.pop(); 
console.log("Final Movie List:");
for (let i = 0; i < movies.length; i++) {
  console.log(movies[i]);
}



// Task 5: User Profile JSON
let user = { name: "Aman", age: 21, course: "JS" };
let jsonString = JSON.stringify(user);
console.log("JSON String:", jsonString);
let userObj = JSON.parse(jsonString);
console.log("Back to Object:", userObj);



// Task 6: Find Max Number in Array without Math.max
let arr = [10, 40, 25, 80, 15];
let max = arr[0];
for (let i = 1; i < arr.length; i++) {
  if (arr[i] > max) {
    max = arr[i];
  }
}
console.log("Maximum Number:", max);



// Task 7: Transform Names Using map()
let names = ["ram", "shyam", "mohan"];
let upperNames = names.map(name => name.toUpperCase());
console.log("Uppercase Names:", upperNames);



