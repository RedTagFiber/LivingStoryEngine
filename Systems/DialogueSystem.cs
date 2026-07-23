using LivingStoryEngine.Characters;
using System.Diagnostics;

namespace LivingStoryEngine.Systems
{
    /// <summary>
    /// Offline dialogue system powered by Ollama.
    /// - llama3: spoken dialogue (smart, conversational)
    /// - phi3: inner thoughts (emotional, introspective)
    /// </summary>
    public static class DialogueSystem
    {
        private const string DialogueModel = "llama3";  // Main speech model
        private const string ThoughtModel = "phi3";     // Emotional thought model

        // ============================================================
        // PUBLIC METHODS
        // ============================================================

        /// <summary>
        /// Generates an NPC's internal emotional thought using phi3.
        /// </summary>
        public static string GenerateThought(Character c)
        {
            string prompt = BuildThoughtPrompt(c);
            return RunLocalLLM(prompt, ThoughtModel);
        }

        /// <summary>
        /// Generates spoken dialogue using llama3.
        /// </summary>
        public static string GenerateDialogue(Character c, string playerMessage)
        {
            string prompt = BuildDialoguePrompt(c, playerMessage);
            return RunLocalLLM(prompt, DialogueModel);
        }

        // ============================================================
        // PROMPT BUILDERS
        // ============================================================

        private static string BuildThoughtPrompt(Character c)
        {
            return $@"
You are {c.Name}, an NPC in a life simulation.
Generate a short emotional inner thought based on your current state.

Emotional State:
- Mood: {c.Mood.Value}
- Stress: {c.Stress.Value}
- Energy: {c.Energy}
- Happiness: {c.Happiness}

Context:
- Current Decision: {c.CurrentDecision}
- Recent Memory: {c.LastEvent}
- Traits: {string.Join(", ", c.SpecialTraits)}

Write the thought in first-person.
Keep it under 2 sentences.
Do NOT speak out loud — this is internal thinking only.
";
        }

        private static string BuildDialoguePrompt(Character c, string playerMessage)
        {
            return $@"
You are {c.Name}, an NPC in a life simulation.
The player says: ""{playerMessage}""

Your emotional state:
- Mood: {c.Mood.Value}
- Stress: {c.Stress.Value}
- Energy: {c.Energy}
- Happiness: {c.Happiness}

Context:
- Current Decision: {c.CurrentDecision}
- Recent Memory: {c.LastEvent}
- Traits: {string.Join(", ", c.SpecialTraits)}

Respond naturally in first-person.
Keep it short (1–2 sentences).
Show subtle emotion based on your state.
";
        }

        // ============================================================
        // OLLAMA EXECUTION
        // ============================================================

        private static string RunLocalLLM(string prompt, string model)
        {
            try
            {
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "ollama",
                        Arguments = $"run {model}",
                        RedirectStandardInput = true,
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    }
                };

                process.Start();

                // Send prompt to the model
                process.StandardInput.WriteLine(prompt);
                process.StandardInput.Close();

                // Read model response
                string response = process.StandardOutput.ReadToEnd();
                process.WaitForExit();

                return response.Trim();
            }
            catch (Exception ex)
            {
                return $"[LLM ERROR: {ex.Message}]";
            }
        }
    }
}
