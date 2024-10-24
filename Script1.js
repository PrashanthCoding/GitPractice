function isArmstrong(num) {
    let digits = num.toString().split('');
    let sum = digits.reduce((acc, digit) => acc + Math.pow(digit, digits.length), 0);
    return sum === num;
}

console.log(isArmstrong(153));  // Output: true (153 = 1³ + 5³ + 3³)
console.log(isArmstrong(123));  // Output: false
