class expCDF{
public float RandEvents(float lambda, int setSize)
    {
        float startVal = 0;  //starting value of the range if off 0
        float eventNum = 0;  //number chosen
        if (lambda - (setSize * 0.25 / 2) > 0)
            startVal = (float)(lambda - (setSize * 0.25 / 2.0)); //if range is off 0, set new starting value
        float[] probs = AssignParts(lambda, setSize); //assign probabilities
        double rand = UnityEngine.Random.value; //rand value to be mapped
        for (int i = 0; i < setSize; i++)
        { //check for when it no longer exceeds prob
            if (rand < probs[i])
            {
                eventNum = (float)((i * 0.25 + startVal));
                break;
            }
        }
        if (probs[setSize - 1] < rand)
        { //if it exceeds highest partition set to highest partition+1 
            eventNum = (float)(startVal + setSize * (0.25));
        }
        Debug.Log(eventNum);
        return eventNum;
    }

    public float[] AssignParts(float lambda, int setSize)
    {
        float[] parts = new float[setSize]; //create array with number of partitions accordingly
        float startVal = 0;
        if (lambda - (setSize * 0.25 / 2.0) > 0)
            startVal = (float)(lambda - (setSize * 0.25 / 2.0));
        //(1-e^(-lambda*x))
        float eVal; //calculated exponential value for every x
        for (int i = 0; i < setSize; i++)
        {
            eVal = (float)(1 - (Math.Pow(Math.E, (-lambda * startVal))));
            parts[i] = eVal;
            startVal += 0.25f;
        }
        return parts; //return set of probabilities
    }
}