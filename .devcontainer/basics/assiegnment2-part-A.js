let a = 5, b = 8;
console.log("Sum =", a + b);

let name = "Shubhra";
console.log("Hello " + name);

let num = 7;
console.log(num % 2 === 0 ? "Even" : "Odd");

let c = 30;
console.log("Fahrenheit =", (c * 9/5) + 32);

let x=9, y=3, z=7;
console.log("Max =", Math.max(x,y,z));

let str = "javascript";
console.log("Length =", str.length);

let flag = true;
flag = !flag;
console.log(flag);

let s1="Hello", s2="World";
console.log(s1 + " " + s2);

let n = -4;
console.log(n>0 ? "Positive" : n<0 ? "Negative" : "Zero");

var s=10;
let h=20;
const m=30;
console.log(s,h,m);


let number = 5;
for(let i=1;i<=10;i++){
    console.log(number + " x " + i + " = " + number*i);
}


let sum=0;
for(let i=1;i<=10;i++) sum+=i;
console.log("Sum =",sum);


let d = 3;
switch(d){
    case 1: console.log("Monday");break;
    case 2: console.log("Tuesday");break;
    case 3: console.log("Wednesday");break;
    case 4: console.log("Thursday");break;
    case 5: console.log("Friday");break;
    case 6: console.log("Saturday");break;
    case 7: console.log("Sunday");break;
    default: console.log("Invalid");
}


function factorial(n){
    let f=1;
    for(let i=1;i<=n;i++) f*=i;
    return f;
}
console.log(factorial(5));


function canVote(age){
    return age>=18 ? "Eligible" : "Not Eligible";
}
console.log(canVote(20));

