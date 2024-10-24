function sumOfNaturalNumbers(n) {
    let sum = 0;
    for (let i = 1; i <= n; i++) {
        sum += i;
    }
    return sum;
}

console.log(sumOfNaturalNumbers(10));  // Output: 55
