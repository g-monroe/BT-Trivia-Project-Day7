import React from 'react';
import { Select } from 'antd';
import { ITriviaGame, Question, Answer } from './types/Superhero.types';

interface ISuperheroPickerProps {
    superheroOptions: Answer[];
    onChange: (newValue: ITriviaGame) => void;
    title: string;
}

class SuperheroPicker extends React.Component<ISuperheroPickerProps> {
    render() {
        return (
       
            <Select defaultValue={`Pick the ${this.props.title}...`} style={{ width: '100%' }} onChange={(newValue: string) => this.onSuperheroChanged(newValue)}>
                {
                    this.props.superheroOptions.map((item, index) =>
                        <>
                        <Select.Option key={index} value={item.AnswerId}>{item.AnswerText}</Select.Option>
                        </>
                    )
                }
            </Select>
        )
    }

    onSuperheroChanged = (newValue: string): void => {
        // let selectedSuperhero: Question | undefined;
        // selectedSuperhero = this.props.superheroOptions.find(item => item.QuestionID === newValue);
        // if (selectedSuperhero) {
        //     this.props.onChange(selectedSuperhero);
        // }
    }
}

export default SuperheroPicker;