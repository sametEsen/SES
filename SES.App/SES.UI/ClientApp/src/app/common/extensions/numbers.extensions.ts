export class NumberExtension {
    public static checkIntegerList(numberList: number[]): boolean {
        let result = true;
        numberList.forEach((val) => {
        if(!Number.isInteger(val))
        {
            result = false;
            return;
        }
        });
        return result;
    }
}