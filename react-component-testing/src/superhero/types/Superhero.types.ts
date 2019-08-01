export interface ITriviaGame {
    GameID: number;
    GameName: string;
    GameStatus: string;
    Questions?: Question[];
    Categories: Category[];
}
export interface Question{
    QuestionID: number;
    Category:Category;
    Winner: number;
    QuestionText:string;
    correctAnswers: Answer[];
    PossibleAnswers: Answer[];
    Disabled: boolean;
}
export interface Category {
    CategoryID: number;
    Description: string;
    Name: string;
    Questions: Question[];
    Disabled: boolean;
}

export interface Answer {
    objects: object[];
    $id: string;
    AnswerId: number;
    QuestionId: number;
    Right: Boolean;
    AnswerText: String;
}
