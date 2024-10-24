class Animal {
    constructor(name, sound) {
        this.name = name;
        this.sound = sound;
    }

    makeSound() {
        console.log(`${this.name} says ${this.sound}`);
    }
}

const dog = new Animal("Dog", "Woof");
dog.makeSound();  // Output: Dog says Woof
