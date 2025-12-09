// 16. Check whether a number is prime or not
function isPrime(n){
    if(n < 2) return "Not Prime";
    for(let i=2;i<=Math.sqrt(n);i++){
        if(n%i===0) return "Not Prime";
    }
    return "Prime";
}
console.log(isPrime(11));


// 17. Print sum of digits of a number (123 → 6)
let num = 123, sum = 0;
while(num>0){
    sum += num % 10;
    num = Math.floor(num/10);
}
console.log("Sum of digits =",sum);


// 18. Reverse a string without using reverse()
function reverseStr(str){
    let rev="";
    for(let i=str.length-1;i>=0;i--){
        rev+=str[i];
    }
    return rev;
}
console.log(reverseStr("hello"));


// 19. Take marks & print Grade A/B/C/Fail
let marks = 82;
if(marks>=90) console.log("Grade A");
else if(marks>=75) console.log("Grade B");
else if(marks>=50) console.log("Grade C");
else console.log("Fail");


// 20. Function → 2 numbers + operator (+ - * /)
function calc(a,b,op){
    if(op==='+') return a+b;
    if(op==='-') return a-b;
    if(op==='*') return a*b;
    if(op==='/') return b!==0 ? a/b : "Error";
}
console.log(calc(10,5,'*'));


// 21. Function to count vowels in string
function countVowels(str){
    let count=0;
    for(let ch of str.toLowerCase()){
        if("aeiou".includes(ch)) count++;
    }
    return count;
}
console.log(countVowels("javascript"));


// 22. Print Fibonacci series up to n terms
let n=10, a=0, b=1;
console.log(a,b);
for(let i=2;i<n;i++){
    let c=a+b;
    console.log(c);
    a=b; b=c;
}


// 23. Return min and max from array
function minMax(arr){
    return {min:Math.min(...arr), max:Math.max(...arr)};
}
console.log(minMax([4,9,1,7,5]));


// 24. Simple Calculator using Switch-case (Add, Sub, Mul, Div)
let f = 10, g = 5;
let choice = 3;   // Change to 1/2/3/4 to test

switch(choice){
    case 1: console.log("Addition =", f + g); break;
    case 2: console.log("Subtraction =", f - g); break;
    case 3: console.log("Multiplication =", f * g); break;
    case 4: console.log("Division =", b !== 0 ? f / g : "Cannot divide by zero"); break;
    default: console.log("Invalid Choice");
}


// 25. Check if a number is Armstrong number or not
function isArmstrong(num){
    let temp = num, sum = 0;
    while(temp > 0){
        let digit = temp % 10;
        sum += digit ** 3;       // cube of each digit
        temp = Math.floor(temp / 10);
    }
    return sum === num ? "Armstrong" : "Not Armstrong";
}

console.log(isArmstrong(153));
console.log(isArmstrong(123));
