export class Deserializer {

    static Deserialize<T>(data: any): T {
        let parsedObject = JSON.parse(JSON.stringify(data));

        let object = <T>{};
        for (let propertyName in parsedObject)
            object[propertyName] = parsedObject[propertyName];

        return object;
    }

    static DeserializeArray<T>(data: any, key?: string): T[] {
        let parsedObject = key ? JSON.parse(JSON.stringify(data))[key] : JSON.parse(JSON.stringify(data));
        
        let objects: T[] = [];
        for(let propertyName in parsedObject) {
            let subObject = parsedObject[propertyName];

            let object = this.Deserialize<T>(subObject);
            objects.push(object);
        }

        return objects;
    }
    
}