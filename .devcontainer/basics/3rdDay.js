function value(x){
    return x*2;


let fruits= [2,4,5,6,"apple","mango"]
}
console.log(value(67));
console.log(value(fruits));



function fruits(num){
    let fal=["apple","mango","grapes","banana","lichi"];
    for(let i=0; i<=num.length-1 ;i++){
        
    }
    return fal;
}
console.log(fruits("fal"));


function fruits(num){
    let fal=["apple","mango","grapes","banana","lichi"];
    for(let i=0; i<=num.length-1 ;i++){
        fal.push("hello")
    }
    return fal;
}
console.log(fruits("fal"));

// Map ....
let number = [2,4,6,8];
let doubles = number.map(n => n*2);
console.log(doubles);


// filter ..... return new array of elements that satisfy a condition
let num = [10,25,30,5,60];
let double = num.filter(n => n>20);
console.log(double)


//reduce
let nums = [1,2,3,4,5];
let total = nums.reduce((acc,val) => acc+val,0);
console.log(total);


//object.... store data in key value pair
let student = {
    name:"shubhra",
    age: 22,
    course: "javascript"
};
console.log(student.name);
