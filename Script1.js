function isPalindrome(str) {
    const reversed = str.split('').reverse().join('');
    return str === reversed;
}

console.log(isPalindrome("madam"));  // Output: true
console.log(isPalindrome("hello"));  // Output: false
