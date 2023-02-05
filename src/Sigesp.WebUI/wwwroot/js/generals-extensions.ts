const monthYear: { id: number, numeral: number, description: string }[] = [
    { id: 0, numeral: 1, description: "JANEIRO"  },
    { id: 1, numeral: 2, description: "FEVEREIRO" },
    { id: 2, numeral: 3, description: "MARCO" },
    { id: 3, numeral: 4, description: "ABRIL" },
    { id: 4, numeral: 5, description: "MAIO" },
    { id: 5, numeral: 6, description: "JUNHO" },
    { id: 6, numeral: 7, description: "JULHO" },
    { id: 7, numeral: 8, description: "AGOSTO" },
    { id: 8, numeral: 9, description: "SETEMBRO" },
    { id: 9, numeral: 10, description: "OUTUBRO" },
    { id: 10, numeral: 11, description: "NOVEMBRO" },
    { id: 11, numeral: 12, description: "DEZEMBRO" }
]

type MyType = {
    id: number;
    name: string;
}

type MyGroupType = {
    [key:string]: MyType;
}

var obj: MyGroupType = {
    "0": { "id": 0, "name": "Available" },
    "1": { "id": 1, "name": "Ready" },
    "2": { "id": 2, "name": "Started" }
};
// or if you make it an array
var arr: MyType[] = [
    { "id": 0, "name": "Available" },
    { "id": 1, "name": "Ready" },
    { "id": 2, "name": "Started" }
];

export namespace GeneralExtensions {
    export const getMonthNumberByDescricao = (descricao: string | undefined) => {
        if (isNullOrEmptyOrUndefined(descricao)) return "Requerido mês do ano."
        return monthYear.find(x => x.description === descricao)
    }

    export const getMonthFullByNumber = (id: number | undefined) => {
        if (id === 0) return "Requerido numeral do mês."
        return monthYear.find(x => x.id === id)
    }
    
    export const isNullOrEmptyOrUndefined = (string: string | undefined) => {
        if (typeof(string) === 'undefined' || string == null || string == '') return true
        return false
    }
}