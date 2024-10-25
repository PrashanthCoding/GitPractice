function generateNumbers(n) {
    return Array.from({ length: n }, (_, i) => i + 1);
}

console.log(generateNumbers(5));  // Output: [1, 2, 3, 4, 5]