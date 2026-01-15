using System;
using System.Collections.Generic;

public class TakingTurnsQueue
{
    private readonly Queue<Person> _people = new Queue<Person>();

    public int Length => _people.Count;

    /// <summary>
    /// Add a person to the queue with the given number of turns
    /// </summary>
    /// <param name=\"name\">Name of the person</param>
    /// <param name=\"turns\">Number of turns (0 or less means infinite)</param>
    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        _people.Enqueue(person);
    }

    /// <summary>
    /// Get the next person in the queue
    /// </summary>
    /// <returns>The next person</returns>
    public Person GetNextPerson()
    {
        if (_people.Count == 0)
        {
            throw new InvalidOperationException(\"No one in the queue.\");
        }

        var person = _people.Dequeue();
        
        // If person has turns left (or infinite turns), add them back
        if (person.Turns > 1 || person.Turns <= 0)
        {
            // Decrease turns if not infinite
            if (person.Turns > 0)
            {
                person.Turns--;
            }
            _people.Enqueue(person);
        }
        // If person.Turns == 1, they used their last turn, don't add back
        
        return person;
    }

    public override string ToString()
    {
        return $\"[{string.Join(\", \", _people)}]\";
    }
}
